/*
 * C17_Ex01: FacebookDataFetcher.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public static class FacebookDataFetcher
    {
        public static object FetchDataWithProgressBar(IEnumerator<Tuple<int, int, object>> i_ProgressOfFetchData, string i_Title)
        {
            object returnedObject = new object();

            try
            {
                if (i_ProgressOfFetchData.MoveNext())
                {
                    Tuple<int, int, object> progressBarValue = i_ProgressOfFetchData.Current;
                    ProgressBarWindow progressBarWindow = new ProgressBarWindow(progressBarValue.Item2, i_Title);
                    
                    progressBarWindow.StartPosition = FormStartPosition.CenterScreen;
                    progressBarWindow.Show();
                    while (i_ProgressOfFetchData.MoveNext())
                    {
                        progressBarValue = i_ProgressOfFetchData.Current;
                        if (progressBarValue.Item1 < progressBarValue.Item2)
                        {
                            progressBarWindow.ProgressValue++;
                        }
                    }

                    progressBarWindow.Close();
                    returnedObject = progressBarValue.Item3;
                }
            }
            catch
            {
                string message = string.Format(
@"Error while fetching data from server.
Please verify internet connection and app permissions");

                MessageBox.Show(message);
            }

            return returnedObject;
        }
    }
}
