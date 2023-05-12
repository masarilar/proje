using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Genel
{
    public static class Genel
    {
        public static SelectList ToSelectList<T>(this List<T> list, string idPropertyName, string namePropertyName = "Name", int? SelectedValue = null) where T : class, new()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();


            foreach (var item in list)
            {
                var text = string.Empty;
                var value = string.Empty;
                if (namePropertyName.Contains('.'))
                {
                    var namePropertyNameSplited = namePropertyName.Split('.');
                    text = item.GetType().GetProperty(namePropertyNameSplited[0]).GetValue(item).GetType().GetProperty(namePropertyNameSplited[1]).GetValue(item.GetType().GetProperty(namePropertyNameSplited[0]).GetValue(item)).ToString();
                    value = item.GetType().GetProperty(idPropertyName).GetValue(item).ToString();
                }
                else
                {
                    text = item.GetType().GetProperty(namePropertyName).GetValue(item).ToString();
                    value = item.GetType().GetProperty(idPropertyName).GetValue(item).ToString();
                }


                selectListItems.Add(new SelectListItem()
                {
                    Text = text,
                    Value = value
                });

            }

            if (SelectedValue != null && Convert.ToInt32(SelectedValue) > 0)
            {
                return new SelectList(selectListItems, "Value", "Text", SelectedValue);
            }
            else
            {
                return new SelectList(selectListItems, "Value", "Text");
            }
        }
    }
}
