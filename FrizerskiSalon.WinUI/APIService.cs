using Flurl.Http;
using eProdaja.Model;
using Newtonsoft.Json;
using System.Text;

namespace FrizerskiSalon.WinUI
{
    public class APIService
    {
        public static string ?Token { get; set; }

        private string? _route = null; 
        public string endpoint = $"{Properties.Settings.Default.ApiURL}";

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object request)
        {
            try
            {
                var url = $"{endpoint}{_route}";
                if (request != null)
                {
                    url += "?";
                    url += await request.ToQueryString();
                }

                var result = await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Neuspješna autentifikacija");
                }
                else
                {
                    MessageBox.Show($"Došlo je do greške -> {ex.Call.Response.StatusCode} error");
                }
                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            try
            {
                var url = $"{endpoint}{_route}/{id}";
                var result = await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Neuspješna autentifikacija");
                }
                else
                {
                    MessageBox.Show($"Došlo je do greške -> {ex.Call.Response.StatusCode} error");
                }
                throw;
            }
        }
        public async Task<T> Insert<T>(object request, string relativeRoute)
        {
            try
            {
                //string url;
                //if (string.IsNullOrEmpty(relativeRoute))
                //{
                //    url = $"{endpoint}{_route}";
                //}
                //else
                //{
                //    url = $"{endpoint}{_route}/{relativeRoute}";
                //}
                var url = string.IsNullOrEmpty(relativeRoute)
    ? $"{endpoint}/{_route}"
    : $"{endpoint}/{_route}/{relativeRoute}";
                var result = await url.WithOAuthBearerToken(Token).PostJsonAsync(request).ReceiveJson<T>();
                //var result = await url.WithOAuthBearerToken(Token).PostJsonAsync(request).ReceiveJson<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Neuspješna autentifikacija");
                }
                else
                {
                    MessageBox.Show($"Došlo je do greške -> {ex.Call.Response.StatusCode} error");
                }
                throw;
            }
        }
        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                var url = $"{endpoint}{_route}/{id}";
                var result = await url.WithOAuthBearerToken(Token).PutJsonAsync(request).ReceiveJson<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Neuspješna autentifikacija");
                }
                else
                {
                    MessageBox.Show($"Došlo je do greške -> {ex.Call.Response.StatusCode} error");
                }
                throw;
            }
        }
        public async Task<bool> Delete(object id)
        {
            try
            {
                var url = $"{endpoint}{_route}/{id}";
                var result = await url.WithOAuthBearerToken(Token).DeleteAsync().ReceiveJson<bool>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Neuspješna autentifikacija");
                }
                else
                {
                    MessageBox.Show($"Došlo je do greške -> {ex.Call.Response.StatusCode} error");
                }
                throw;
            }
        }

        public async Task<T> Login<T>(object request, string relativeRoute)
        {
            try
            {
                string url;
                if (string.IsNullOrEmpty(relativeRoute))
                {
                    url = $"{endpoint}{_route}";
                }
                else
                {
                    url = $"{endpoint}{_route}/{relativeRoute}";
                }

                var result = await url.PostJsonAsync(request).ReceiveJson<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    MessageBox.Show("Neuspješna autentifikacija");
                }
                else
                {
                    MessageBox.Show($"Došlo je do greške -> {ex.Call.Response.StatusCode} error");
                }
                throw;
            }
        }
    }
}
