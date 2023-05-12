using System.ComponentModel;

namespace ModelDto.Enums {
    public enum RestRequestContentType {
        [Description("application/json")] application_json,
        [Description("application/x-www-form-urlencoded")] application_x_www_form_urlencoded
    }
}
