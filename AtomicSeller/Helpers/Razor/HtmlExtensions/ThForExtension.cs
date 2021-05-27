using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class ThForExtension
    {
        public static MvcHtmlString ThFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            
            var innerText = metadata.DisplayName ?? metadata.PropertyName;
            
            return new MvcHtmlString(innerText);
        }
    }
}
