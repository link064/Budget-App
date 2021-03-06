﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using Budget_App.Models;

namespace Budget_App.Views
{
    public partial class BalanceGraph : Form
    {
        private string DATEFORMAT = MainForm.DATEFORMAT;
        private GraphPeriod _period;
        private DateTime _startDate;
        private DateTime _endDate;

        public BalanceGraph()
        {
            InitializeComponent();
            cmbType.DataSource = Enum.GetValues(typeof(GraphPeriod));
        }

        public void AddPoints(List<object> Xpoints, List<object> Ypoints, string series)
        {
            if (Xpoints == null || Ypoints == null || Xpoints.Count != Ypoints.Count)
                return;

            if (chart1.Series.Where(s => s.Name == series).FirstOrDefault() == null)
                chart1.Series.Add(new Series(series)
                {
                    ChartArea = "ChartArea1",
                    ChartType = SeriesChartType.Line,
                    Legend = "Legend1",
                    XValueType = ChartValueType.String
                });

            // Clear out the points just in case
            chart1.Series[series].Points.Clear();           

            for (int i = 0; i < Xpoints.Count; i++)
                chart1.Series[series].Points.AddXY(Xpoints[i], Ypoints[i]);            
        }

        private void Chart1_GetToolTipText_1(object sender, ToolTipEventArgs e)
        {
            try
            {
                // Check selected chart element and set tooltip text
                if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    int i = e.HitTestResult.PointIndex;
                    DataPoint dp = e.HitTestResult.Series.Points[i];
                    e.Text = string.Format("{0:F1}, {1:F1}", GetDateList(_period, _startDate, _endDate)[i], dp.YValues[0]);
                }
            }
            catch
            {
            }
        }

        private List<string> GetDateList(GraphPeriod period, DateTime startDate, DateTime endDate)
        {
            List<TransactionItem> items = TransactionItem.GetCollection().Find(t => t.TransDate >= startDate && t.TransDate <= endDate).ToList();
            switch (period)
            {
                case GraphPeriod.Annual:
                    return items.Select(i => i.TransDate.ToString("yyyy")).Distinct().ToList();

                case GraphPeriod.Monthly:
                    return items.Select(i => i.TransDate.ToString(DATEFORMAT)).Distinct().ToList();

                case GraphPeriod.Weekly:
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    Calendar cal = dfi.Calendar;
                    return items.Select(i => string.Format("Week {0} {1}", cal.GetWeekOfYear(i.TransDate, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), i.TransDate.ToString("yyyy"))).Distinct().ToList();

                default:
                    return new List<string>();
            }            
        }

        private bool IsDateInPeriod(string periodDate, DateTime dateToCheck, GraphPeriod period)
        {
            switch (period)
            {
                case GraphPeriod.Annual:
                    return periodDate == dateToCheck.ToString("yyyy");
                    
                case GraphPeriod.Monthly:
                    return periodDate == dateToCheck.ToString(DATEFORMAT);

                case GraphPeriod.Weekly:
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    Calendar cal = dfi.Calendar;
                    return periodDate == string.Format("Week {0} {1}",
                        cal.GetWeekOfYear(dateToCheck, dfi.CalendarWeekRule,
                                          dfi.FirstDayOfWeek), dateToCheck.ToString("yyyy"));
                
                default:
                    return false;
            }
        }

        private string GetFriendlyAccountNames(string account)
        {
            // TODO: make a way to make nickname accounts
            return account;
        }
        
        public void GeneratePointsLists(GraphPeriod period, bool addTotal = true, bool addTrend = false, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (startDate == null || startDate.Value <= DateTime.MinValue || startDate.Value >= DateTime.MaxValue)
                startDate = TransactionItem.GetCollection().Find(t => t.TransDate > DateTime.MinValue).Min(t => t.TransDate).AddDays(-1);
            if (endDate == null || endDate.Value <= DateTime.MinValue || endDate.Value >= DateTime.MaxValue)
                endDate = DateTime.Today;
                        
            _period = period;
            cmbType.SelectedItem = period;
            _startDate = startDate.Value;
            _endDate = endDate.Value;
            dtpStartDate.Value = startDate.Value;
            dtpEndDate.Value = endDate.Value;

            Dictionary<string, List<object>[]> data = new Dictionary<string, List<object>[]>();
            List<string> dates = GetDateList(_period, _startDate, _endDate);

            // Make the intervals match up with the number of entries we have
            switch (period)
            {
                case GraphPeriod.Annual:
                    break;
                case GraphPeriod.Monthly:
                    chart1.ChartAreas[0].AxisX.Interval = Math.Min(3, Math.Ceiling(((_endDate - _startDate).Days / 30) / 12.0d));                    
                    break;
                case GraphPeriod.Weekly:
                    chart1.ChartAreas[0].AxisX.Interval = Math.Min(5, Math.Ceiling(((_endDate - _startDate).Days / 7) / 26.0d));                    
                    break;
            }

            chart1.Titles[0].Text = period.ToString();

            // group by account
            var items = TransactionItem.GetCollection().FindAll().GroupBy(i => i.Account);
            foreach (var group in items)
            {
                List<object>[] dateAndAmount = new List<object>[2];
                dateAndAmount[0] = new List<object>();
                dateAndAmount[1] = new List<object>();
                // group by date
                foreach (string date in dates)
                {
                    string lastDate = string.Empty;
                    decimal balance = 0.00M;
                    // search transactions
                    foreach (TransactionItem item in group)
                    {
                        // Janky, but the best way we can do this without having both a date and a time for each transaction
                        // is to go through the list until you find the first applicable transaction for a given period and
                        // add it to the list of data points. While this may be inaccurate on an individual by-date level,
                        // it should show a consistent level over a number of data points
                        if (IsDateInPeriod(date, item.TransDate, period))
                        {
                            lastDate = date;
                            balance = item.Balance;                           
                        }
                    }

                    if (!string.IsNullOrEmpty(lastDate))
                    {
                        dateAndAmount[0].Add(lastDate);
                        dateAndAmount[1].Add(balance);
                    }
                    else
                    {
                        if (dateAndAmount[1].Count > 0)
                        {
                            dateAndAmount[0].Add(date);
                            dateAndAmount[1].Add(dateAndAmount[1].Last());
                        }
                    }
                }
                data.Add(GetFriendlyAccountNames(group.Key), dateAndAmount);
            }

            // If we want to add a total over all the accounts
            if (addTotal)
            {
                List<object>[] dateAndAmount = new List<object>[2];
                dateAndAmount[0] = new List<object>();
                dateAndAmount[1] = new List<object>();
                // go through each possible date
                foreach (string date in dates)
                {
                    decimal total = 0.00M;
                    // go through each account
                    foreach (KeyValuePair<string, List<object>[]> kvp in data)
                    {
                        // search each row...
                        for (int i = 0; i < kvp.Value[0].Count; i++)
                        {
                            // look for the corresponding date
                            if (((string)kvp.Value[0][i]) == date)
                            {
                                // add to the running total
                                total += (decimal)kvp.Value[1][i];
                                break;
                            }
                        }
                    }
                    dateAndAmount[0].Add(date);
                    dateAndAmount[1].Add(total);
                }
                data.Add("Total", dateAndAmount);
            }

            if (addTrend)
            {
                List<object>[] dateAndAmount = data["Total"];
                if (dateAndAmount != null && dateAndAmount[0].Count > 0)
                {
                    decimal slope = (((decimal)dateAndAmount[1].Last()) - ((decimal)dateAndAmount[1].First())) / (decimal)dateAndAmount[1].Count;
                    decimal intercept = (decimal)dateAndAmount[1].First();

                    List<object>[] trendLine = new List<object>[2];
                    trendLine[0] = new List<object>();
                    trendLine[1] = new List<object>();

                    for (int i = 0; i < dateAndAmount[0].Count; i++)
                    {
                        trendLine[0].Add(dateAndAmount[0][i]);
                        trendLine[1].Add(intercept + (slope * i));
                    }

                    switch (period)
                    {
                        case GraphPeriod.Monthly:
                            trendLine[0].Add("Next month");
                            trendLine[1].Add(intercept + (slope * dateAndAmount[0].Count));
                            break;
                        case GraphPeriod.Weekly:
                            for (int i = 0; i < 4; i++)
                            {
                                trendLine[0].Add("Next week " + (i + 1).ToString());
                                trendLine[1].Add(intercept + (slope * (dateAndAmount[0].Count + i)));
                            }
                            break;
                        default:
                            break;
                    }

                    data.Add("Trend", trendLine);
                }
            }
            else
            {
                List<object>[] dateAndAmount = data["Total"];
                if (dateAndAmount != null && dateAndAmount[0].Count > 0)
                {
                    List<object>[] trendLine = new List<object>[2];
                    trendLine[0] = new List<object>();
                    trendLine[1] = new List<object>();
                    trendLine[0].Add(dateAndAmount[0][0]);
                    trendLine[1].Add(dateAndAmount[1][0]);

                    data.Add("Trend", trendLine);
                }
            }

            foreach (KeyValuePair<string, List<object>[]> kvp in data)
                AddPoints(kvp.Value[0], kvp.Value[1], kvp.Key);            
        }

        private void BalanceGraph_ResizeEnd(object sender, EventArgs e)
        {
            this.chart1.Size = new Size(this.Size.Width - 40, this.Size.Height - 91);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            GeneratePointsLists(_period, true, cbTrendLine.Checked, dtpStartDate.Value, _endDate);
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            GeneratePointsLists(_period, true, cbTrendLine.Checked, _startDate, dtpEndDate.Value);
        }

        private void cbTrendLine_CheckedChanged(object sender, EventArgs e)
        {
            GeneratePointsLists(_period, true, cbTrendLine.Checked, dtpStartDate.Value, dtpEndDate.Value);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeneratePointsLists((GraphPeriod)cmbType.SelectedValue, true, cbTrendLine.Checked, dtpStartDate.Value, _endDate);
        }
    }

    public enum GraphPeriod
    {
        Annual,
        Monthly,
        Weekly
    }
}
