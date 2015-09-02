using System.CodeDom;
using System.IO;
using System.Xml.Serialization;

namespace TypescriptCodeDom.CodeExpressions
{
    public interface IExpressionFactory
    {
        IExpression<T> GetExpression<T>(T expression)
            where T : CodeExpression;
    }
}