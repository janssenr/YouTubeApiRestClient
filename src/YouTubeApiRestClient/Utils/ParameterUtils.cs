using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace YouTubeApiRestClient.Utils
{
    public static class ParameterUtils
    {
        /// <summary>
        /// Creates a <see cref="System.Net.Http.FormUrlEncodedContent"/> with all the specified parameters in 
        /// the input request. It uses reflection to iterate over all properties with
        /// <see cref="RequestParameterAttribute"/> attribute.
        /// </summary>
        /// <param name="request">
        /// A request object which contains properties with 
        /// <see cref="RequestParameterAttribute"/> attribute. Those properties will be serialized
        /// to the returned <see cref="System.Net.Http.FormUrlEncodedContent"/>.
        /// </param>
        /// <returns>
        /// A <see cref="System.Net.Http.FormUrlEncodedContent"/> which contains the all the given object required 
        /// values.
        /// </returns>
        public static FormUrlEncodedContent CreateFormUrlEncodedContent(object request)
        {
            IList<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            IterateParameters(request, (type, name, value) =>
            {
                list.Add(new KeyValuePair<string, string>(name, value.ToString()));
            });
            return new FormUrlEncodedContent(list);
        }

        /// <summary>
        /// Creates a parameter dictionary by using reflection to iterate over all properties with
        /// <see cref="RequestParameterAttribute"/> attribute.
        /// </summary>
        /// <param name="request">
        /// A request object which contains properties with 
        /// <see cref="RequestParameterAttribute"/> attribute. Those properties will be set
        /// in the output dictionary.
        /// </param>
        public static IDictionary<string, object> CreateParameterDictionary(object request)
        {
            var dict = new Dictionary<string, object>();
            IterateParameters(request, (type, name, value) =>
            {
                dict.Add(name, value);
            });
            return dict;
        }

        public static List<KeyValuePair<string, string>> CreateParameterKeyValuePairs(object request)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            IterateParameters(request, (type, name, value) =>
            {
                if (value != null)
                {
                    parameters.Add(new KeyValuePair<string, string>(name, value.ToString()));
                }
            });
            return parameters;
        }

        /// <summary>
        /// Iterates over all <see cref="RequestParameterAttribute"/> properties in the request
        /// object and invokes the specified action for each of them.
        /// </summary>
        /// <param name="request">A request object</param>
        /// <param name="action">An action to invoke which gets the parameter type, name and its value</param>
        private static void IterateParameters(object request, Action<RequestParameterType, string, object> action)
        {
            // Use reflection to build the parameter dictionary.
            foreach (PropertyInfo property in request.GetType().GetProperties(BindingFlags.Instance |
                                                                              BindingFlags.Public))
            {
                // Retrieve the RequestParameterAttribute.
                RequestParameterAttribute attribute =
                    property.GetCustomAttributes(typeof(RequestParameterAttribute), false).FirstOrDefault() as
                        RequestParameterAttribute;
                if (attribute == null)
                {
                    continue;
                }

                // Get the name of this parameter from the attribute, if it doesn't exist take a lower-case variant of
                // property name.
                string name = attribute.Name ?? property.Name.ToLower();

                var propertyType = property.PropertyType;
                var value = property.GetValue(request, null);

                // Call action with the type name and value.
                if (propertyType.IsValueType || value != null)
                {
                    if (attribute.Type == RequestParameterType.UserDefinedQueries)
                    {
                        if (typeof(IEnumerable<KeyValuePair<string, string>>).IsAssignableFrom(value.GetType()))
                        {
                            foreach (var pair in (IEnumerable<KeyValuePair<string, string>>)value)
                            {
                                action(RequestParameterType.Query, pair.Key, pair.Value);
                            }
                        }
                    }
                    else
                    {
                        action(attribute.Type, name, value);
                    }
                }
            }
        }
    }
}
