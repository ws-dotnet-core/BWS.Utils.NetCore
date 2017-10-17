using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BWS.Utils.NetCore.Expressions {

    internal class ParameterReplacer : ExpressionVisitor {

        private readonly ParameterExpression _parameter;

        protected override Expression VisitParameter(ParameterExpression node) {
            return base.VisitParameter(_parameter);
        }

        internal ParameterReplacer(ParameterExpression parameter) {
            _parameter = parameter;
        }

    }

    /// <summary>
    /// ExpressionTree Extensions.
    /// </summary>
    public static class ExpressionTreesExtensions {

        /// <summary>
        /// Union the filter with And method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2) {
            var param = Expression.Parameter(typeof(T));
            var body = Expression.AndAlso(expr1.Body, expr2.Body);
            return Expression.Lambda<Func<T, bool>>((BinaryExpression)new ParameterReplacer(param).Visit(body), param);
        }

        /// <summary>
        /// Filt the filter with Or method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2) {
            var param = Expression.Parameter(typeof(T));
            var body = Expression.OrElse(expr1.Body, expr2.Body);
            return Expression.Lambda<Func<T, bool>>((BinaryExpression)new ParameterReplacer(param).Visit(body), param);
        }

    }
}
