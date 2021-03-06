﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Linq.Expressions;
using Fireasy.Data.Entity.Metadata;

namespace Fireasy.Data.Entity.Linq.Expressions
{
    /// <summary>
    /// 表示数据实体的表达式。
    /// </summary>
    public sealed class EntityExpression : DbExpression
    {
        /// <summary>
        /// 初始化 <see cref="EntityExpression"/> 类的新实例。
        /// </summary>
        /// <param name="meta">实体元数据对象。</param>
        /// <param name="expression">定义的 Linq 表达式。</param>
        /// <param name="isNoTracking"
        public EntityExpression(EntityMetadata meta, Expression expression, bool isNoTracking)
            : base(DbExpressionType.Entity, expression.Type)
        {
            Metadata = meta;
            Expression = expression;
            IsNoTracking = isNoTracking;
        }

        /// <summary>
        /// 获取实体元数据对象。
        /// </summary>
        public EntityMetadata Metadata { get; private set; }

        /// <summary>
        /// 获取定义的 Linq 表达式。
        /// </summary>
        public Expression Expression { get; private set; }

        /// <summary>
        /// 获取是否不跟踪状态。
        /// </summary>
        public bool IsNoTracking { get; private set; }

        /// <summary>
        /// 更新 <see cref="EntityExpression"/> 对象。
        /// </summary>
        /// <param name="expression">定义的 Linq 表达式。</param>
        /// <returns></returns>
        public EntityExpression Update(Expression expression, bool isNoTracking)
        {
            return expression != Expression ? new EntityExpression(Metadata, expression, isNoTracking) : this;
        }
    }
}
