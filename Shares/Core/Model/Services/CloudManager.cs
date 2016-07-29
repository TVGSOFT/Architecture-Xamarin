using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Model.Services
{
    public class CloudManager
    {

        #region Properties

		private string baseUrl;

        #endregion

        #region Constructors

		public CloudManager(string baseUrl)
        {
			this.baseUrl = baseUrl;
        }

        #endregion

        #region Protected Methods

		public async Task<T> GetAsync<T>(string method, IDictionary<string, object> parameters) where T : class
        {
            var url = method;
            if (parameters != null)
            {
                url += BuildParameters(parameters);
            }

            try
            {
				using (var httpClient = DefaultHttpClient)
				{
					var response = await httpClient.GetStringAsync(url);
					if (response != null)
					{
						var settings = new JsonSerializerSettings();
						settings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

						var data = JsonConvert.DeserializeObject<T>(response, settings);

						return data;
					}
				}
            }
            catch (Exception e)
            {
                LogError(e.Message);
            }
            return default(T);
        }

		public async Task<T> PostAsync<T>(string method, T parameter) where T : class
		{
			try
			{
				using (var httpClient = DefaultHttpClient)
				{
					var response = await httpClient.PostAsJsonAsync(method, parameter);
					var content = await response?.Content?.ReadAsStringAsync();
					if (content != null)
					{
						var settings = new JsonSerializerSettings();
						settings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

						var data = JsonConvert.DeserializeObject<T>(content, settings);
						return data;
					}
				}
			}
			catch (Exception e)
			{
				LogError(e.Message);
			}
			return default(T);
		}

		public async Task<T> PutAsync<T>(string method, T parameter) where T : class
		{
			try
			{
				using (var httpClient = DefaultHttpClient)
				{
					var response = await httpClient.PutAsJsonAsync(method, parameter);
					var content = await response?.Content?.ReadAsStringAsync();
					if (content != null)
					{
						var settings = new JsonSerializerSettings();
						settings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

						var data = JsonConvert.DeserializeObject<T>(content, settings);
						return data;
					}
				}
			}
			catch (Exception e)
			{
				LogError(e.Message);
			}
			return default(T);
		}

		#endregion

		#region Private Methods

		private HttpClient DefaultHttpClient
		{
			get
			{
				var httpClient = new HttpClient();
				httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(baseUrl);
				httpClient.Timeout = new TimeSpan(0, 1, 0);

				return httpClient;
			}
		}

		private string FormatDateTimeParameters(DateTime dateTime)
		{
			return dateTime.ToUniversalTime().ToString("MM/dd/yyyy hh:mm:ss tt");
		}

        private string BuildParameters(IDictionary<string, object> parameters)
        {
            string result = null;

            foreach (var param in parameters)
            {
                object value = null;
                if (param.Value is DateTime)
                {
                    value = FormatDateTimeParameters((DateTime)param.Value);
                }
                else
                {
                    value = param.Value;
                }

                if (string.IsNullOrEmpty(result))
                {
                    result = $"?{param.Key}={value}";
                }
                else
                {
                    result += $"&{param.Key}={value}";
                }
            }

            return result;
        }

        protected void LogError(string message)
        {
        
        }

        #endregion

    }
}
