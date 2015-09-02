using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions
{
    public interface IExpression
    {
    }

    public interface IExpression<T> : IExpression 
        where T : CodeExpression
    {
        string Evaluate(T codeExpression, CodeGeneratorOptions options);
    }
}