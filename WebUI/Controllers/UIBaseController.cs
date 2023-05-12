using Microsoft.AspNetCore.Mvc;
using ModelDto.Enums;
using RestSharp;
using WebUI.Genel;

namespace WebUI.Controllers {
    public class UIBaseController : Controller {
        private readonly IRestSharpRequest _restSharpRequest;

        public UIBaseController(IRestSharpRequest restSharpRequest) {
            _restSharpRequest = restSharpRequest;
        }
        public async Task<T> SendRequest<T>(string url, Method method, RestRequestContentType restRequestContentType = RestRequestContentType.application_json, object body = null)
            => await _restSharpRequest.SendRequest<T>(url, method, restRequestContentType, body);

        public async Task<T> SendRequestWithoutToken<T>(string url, Method method, RestRequestContentType restRequestContentType = RestRequestContentType.application_json, object body = null)
            => await _restSharpRequest.SendRequestWithoutToken<T>(url, method, restRequestContentType, body);

    }
}