using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace VMS.Infrastructure.Utility
{
    public class DataTableAjaxRequest
    {
        private HttpRequest _request;

        public DataTableAjaxRequest(HttpRequest request)
        {
            _request = request;
        }

        private IEnumerable<KeyValuePair<String, StringValues>> RequestData
        {
            get
            {
                var method = _request.Method.ToLower();
                if (method == "get")
                {
                    return _request.Query;
                }
                else if (method == "post")
                {
                    return _request.Form;
                }
                else
                {
                    throw new InvalidOperationException("Http Request Method Is not get or post");
                }
            }
        }
        public int Start
        {
            get
            {
                return int.Parse(RequestData.Where(x => x.Key == "start").FirstOrDefault().Value);
            }
        }

        public int Length
        {
            get
            {
                return int.Parse(RequestData.Where(x => x.Key == "length").FirstOrDefault().Value);
            }
        }

        public String SearchText
        {
            get { return RequestData.Where(x => x.Key == "search[value]").FirstOrDefault().Value; }
        }

        public int PageIndex
        {
            get
            {
                if (Length > 0)
                {
                    return (Start / Length) + 1;
                }
                else
                {
                    return 1;
                }
            }
        }

        public int PageSize
        {
            get
            {
                if (Length == 0)
                {
                    return 10;
                }
                else
                {
                    return Length;
                }
            }
        }

        public static object EmptyRequest
        {
            get
            {

                return new
                {
                    recordsTotal = 0,
                    recordsFilterd = 0,
                    data = (new String[] { }).ToArray()
                };
            }
        }

        public string GetSortText(string[] columnNames)
        {
            var sortText = new StringBuilder();

            for (int i = 0; i < columnNames.Length; i++)
            {
                if (RequestData.Any(x => x.Key == $"order[{i}][column]"))
                {
                    if (sortText.Length > 0)
                    {
                        sortText.Append(",");
                    }

                    var ColumnmValues = RequestData
                        .Where(x => x.Key == $"order[{i}][column]")
                        .FirstOrDefault();

                    var directionValue = RequestData
                        .Where(x => x.Key == $"order[{i}][dir]")
                        .FirstOrDefault();

                    var column = int.Parse(ColumnmValues.Value.ToArray()[0]);
                    var dir = directionValue.Value.ToArray()[0];

                    var sortDirection = $"{columnNames[column]}{(dir == "asc" ? "asc" : "desc")}";

                    sortText.Append(sortDirection);
                }
            }

            return sortText.ToString();
        }
    }
}
