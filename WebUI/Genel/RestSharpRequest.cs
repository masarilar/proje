using EnumsNET;
using ModelDto.Enums;
using Newtonsoft.Json;
using RestSharp;

namespace WebUI.Genel {
    public interface IRestSharpRequest {
        Task<T> SendRequest<T>(string url, Method method, RestRequestContentType restRequestContentType = RestRequestContentType.application_json, object body = null);
        Task<T> SendRequestWithoutToken<T>(string url, Method method, RestRequestContentType restRequestContentType = RestRequestContentType.application_json, object body = null);
    }
    public class RestSharpRequest : IRestSharpRequest {
        private readonly IConfiguration _configuration;
        public RestSharpRequest(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task<T> SendRequest<T>(string url, Method method, RestRequestContentType restRequestContentType = RestRequestContentType.application_json, object body = null) {
            var client = new RestClient(_configuration.GetValue<string>("WebApiUrl") + url) {
                Timeout = -1
            };
            var request = new RestRequest(method);
            //request.AddHeader("Authorization", "Bearer " + SessionBilgi.Current.token.access_token);
            request.AddHeader("Content-Type", restRequestContentType.AsString(EnumFormat.Description));
            if (method != Method.GET) {
                if (restRequestContentType == RestRequestContentType.application_json) {
                    request.AddJsonBody(body);
                } else {
                    foreach (var item in body.GetType().GetProperties()) {
                        request.AddParameter(item.Name, item.GetValue(body, null));
                    }
                }
            }

            var response = await client.ExecuteAsync(request);
            var serializedResponse = JsonConvert.DeserializeObject<T>(response.Content);
            return serializedResponse;
        }
        public async Task<T> SendRequestWithoutToken<T>(string url, Method method, RestRequestContentType restRequestContentType = RestRequestContentType.application_json, object body = null) {
            var client = new RestClient(_configuration.GetValue<string>("WebApiUrl") + url) {
                Timeout = -1
            };
            var request = new RestRequest(method);
            request.AddHeader("Content-Type", restRequestContentType.AsString(EnumFormat.Description));
            if (method != Method.GET) {
                if (restRequestContentType == RestRequestContentType.application_json) {
                    request.AddJsonBody(body);
                } else {
                    foreach (var item in body.GetType().GetProperties()) {
                        request.AddParameter(item.Name, item.GetValue(body, null));
                    }
                }
            }

            var response = await client.ExecuteAsync(request);
            var serializedResponse = JsonConvert.DeserializeObject<T>(response.Content);
            return serializedResponse;
        }
    }
}
