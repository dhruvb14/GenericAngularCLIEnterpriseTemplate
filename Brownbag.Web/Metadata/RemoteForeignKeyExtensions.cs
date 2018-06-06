using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Brownbag.Web.Models;
using Brownbag.Web.Models.PrimeNG.Grid;
using Brownbag.Web.Repository;
// using Kendo.Mvc.Extensions;
// using Kendo.Mvc.UI;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Brownbag.Web.Metadata {
    public static class RemoteForeignKeyExtensions {
        public static async Task FetchForeignKeysForViewModelAsync<T>(this GridViewModel<T> result, GenericForeignKeyRepository genericFKRepo) {
            var keys = typeof(T).GetProperties().Where(e => e.CustomAttributes.Any(y => y.AttributeType.FullName.Contains("RemoteForeignKeyAttribute")));
            foreach (var key in keys) {
                string Repository, Endpoint, IDField, ValueField, Delimiter, Lookup = null;
                string StringLiteral = "true";
                /*
                 * Get Fields from VM required for FK data calls
                 */
                Repository = key.GetCustomAttributesData().First().NamedArguments.Where(asd => asd.MemberName == "Repository").Select(u => u.TypedValue.Value).FirstOrDefault() as string;
                Endpoint = key.GetCustomAttributesData().First().NamedArguments.Where(asd => asd.MemberName == "Endpoint").Select(u => u.TypedValue.Value).FirstOrDefault() as string;
                IDField = key.GetCustomAttributesData().First().NamedArguments.Where(asd => asd.MemberName == "IDField").Select(u => u.TypedValue.Value).FirstOrDefault() as string;
                ValueField = key.GetCustomAttributesData().First().NamedArguments.Where(asd => asd.MemberName == "ValueField").Select(u => u.TypedValue.Value).FirstOrDefault() as string;
                StringLiteral = key.GetCustomAttributesData().First().NamedArguments.Where(asd => asd.MemberName == "StringLiteral").Select(u => u.TypedValue.Value).FirstOrDefault() as string;
                Delimiter = key.GetCustomAttributesData().First().NamedArguments.Where(asd => asd.MemberName == "Delimiter").Select(u => u.TypedValue.Value).FirstOrDefault() as string;
                Lookup = key.GetCustomAttributesData().First().NamedArguments.Where(asd => asd.MemberName == "Lookup").Select(u => u.TypedValue.Value).FirstOrDefault() as string;
                /*
                 * Loop through the filtered dataset and go get the required 
                 * remote data using the configuration properties gathered 
                 * from above
                 */
                foreach (T item in result.Data) {
                    var propertyInfo = item.GetType().GetProperty(key.Name);
                    if (propertyInfo != null && propertyInfo.CanWrite) {
                        var setter = propertyInfo.SetMethod;
                        if (StringLiteral == "true" && IDField != null) {
                            var id = Int32.Parse((item.GetType().GetProperty(IDField).GetValue(item).ToString()));
                            var results = await genericFKRepo.GetGenericForeignKeyByIdAsync(id, Repository, Endpoint);
                            setter.Invoke(item, new object[] { ValueField.ConcatValues(results, Delimiter) });
                        }
                        if (Lookup == "true" && StringLiteral == "false") {
                            /*
                             * Loop through the filtered dataset and go get the required 
                             * remote data using the configuration properties gathered 
                             * from above
                             */
                            var results = await genericFKRepo.GetGenericRemoteLookupsAsync(Repository, Endpoint);
                            setter.Invoke(item, new object[] { ValueField.ConcatValuesForLookup(results, Delimiter, IDField) });
                            // var a = await genericFKRepo.GetSectionPOCCostCodeByIdObjAsync(id);
                            // setter.Invoke(item, new object[] { a.Value });
                        }
                    }
                }
            }
        }

        /**
         * If Using Kendo, then uncomment this code, add back in the 2 commented using's at the top and change the signature for FetchForeignKeysForViewModelAsync to:
         * public static async Task FetchForeignKeysForViewModelAsync<T>(this DataSourceResult result, GenericForeignKeyRepository genericFKRepo)
         */

        /*
        public static async Task<DataSourceResult> ToDataSourceResultWithRemoteFKAsync<TModel, TResult>(this IQueryable<TModel> enumerable, DataSourceRequest request, Func<TModel, TResult> selector, GenericForeignKeyRepository genericFKRepo) {
             var results = enumerable.ToDataSourceResult(request, selector);
             await results.FetchForeignKeysForViewModelAsync<TResult>(genericFKRepo);
             return results;
         }
        */

        public static string ConcatValues(this string fields, Dictionary<string, dynamic> data, string delimiter) {
            var keys = fields.Split(',').ToList<string>();
            string result = String.Empty;
            for (int i = 0; i < keys.Count; i++) {
                if (i > 0) {
                    result = result + delimiter;
                }
                result = result + data[keys[i]];
            }
            return result;
        }
        public static IList<LookupViewModel> ConcatValuesForLookup(this string fields, IList<Dictionary<string, dynamic>> data, string delimiter, string id) {
            var keys = fields.Split(',').ToList<string>();
            IList<LookupViewModel> result = new List<LookupViewModel>();
            for (int i = 0; i < data.Count; i++) {
                var title = String.Empty;
                for (int j = 0; j < keys.Count; j++) {
                    if (j > 0) {
                        title = title + delimiter;
                    }
                    title = title + data[i][keys[j]];
                }
                try {
                    var item = new LookupViewModel() {
                        ID = unchecked((int) (data[i][id])),
                        Value = title
                    };
                    result.Add(item);

                } catch (Exception e) {
                    Console.Write(e);
                }

            }
            return result;
        }
    }
}