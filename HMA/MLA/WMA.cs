using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMA.MLA
{
    public class WMA
    {
        public static double? WeightedMovingAverage(double[] values, int extension, params double[] periodWeight)
        {
            double test = 0;
            foreach (double weight in periodWeight)
            {
                test += weight;
            }
            if (test != 1)
            {
               return null;
            }

            ForecastTable dt = new ForecastTable();

            for (Int32 i = 0; i < values.Length + extension; i++)
            {
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);

                row.BeginEdit();
                row["Instance"] = i;

                if (i < values.Length)
                {
                    row["Value"] = values[i];
                }

                if (i == 0)
                {
                    row["Forecast"] = values[i];
                }
                else if ((i < values.Length) && (i < periodWeight.Length))
                {
                    double avg = 0;

                    
                    DataRow[] rows = dt.Select("Instance>=" + (i - periodWeight.Length).ToString() + " AND Instance < " + i.ToString(), "Instance");
                    for (int j = 0; j < rows.Length; j++)
                    {
                        avg += (Double)rows[j]["Value"] * (1 / rows.Length);
                    }
                    row["Forecast"] = avg;
                }
                else if ((i < values.Length) && (i >= periodWeight.Length))
                {
                    double avg = 0;
                    
                    DataRow[] rows = dt.Select("Instance>=" + (i - periodWeight.Length).ToString() + " AND Instance < " + i.ToString(), "Instance");
                    for (int j = 0; j <= rows.Length - 1; j++)
                    {
                        avg += (Double)rows[j]["Value"] * periodWeight[j];
                    }
                  
                    row["Forecast"] = avg;
                }
                else
                {
                    double avg = 0;

                    DataRow[] rows = dt.Select("Instance>=" + (i - periodWeight.Length).ToString() + " AND Instance < " + i.ToString(), "Instance");
                    for (int j = 0; j < rows.Length; j++)
                    {
                        avg += (Double)rows[j]["Forecast"] * periodWeight[j];
                    }
                    row["Forecast"] = avg;
                }
                row.EndEdit();
            }

            dt.AcceptChanges();
            return (double)dt.Rows[dt.Rows.Count-1]["Forecast"];
        }
    }
    public class ForecastTable : DataTable
    {
        public ForecastTable()                           
        {
            this.Columns.Add("Instance", typeof(Int32)); 
            this.Columns.Add("Value", typeof(Double));   
            this.Columns.Add("Forecast", typeof(Double));
            this.Columns.Add("Holdout", typeof(Boolean));

            //E(t) = D(t) - F(t)
            this.Columns.Add("Error", typeof(Double), "Forecast-Value");
            //Absolute Error = |E(t)|
            this.Columns.Add("AbsoluteError", typeof(Double), "IIF(Error>=0, Error, Error * -1)");
            //Percent Error = E(t) / D(t)
            this.Columns.Add("PercentError", typeof(Double), "IIF(Value<>0, Error / Value, Null)");
            //Absolute Percent Error = |E(t)| / D(t)
            this.Columns.Add("AbsolutePercentError", typeof(Double), "IIF(Value <> 0, AbsoluteError / Value, Null)");
        }
    }
}
