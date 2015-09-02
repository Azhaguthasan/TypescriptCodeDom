using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace TypescriptCodeDom.CodeExpressions
{
    public static class Extensions
    {
        public static IEnumerable<string> GetParametersFromExpressions(this CodeExpressionCollection codeExpressions, IExpressionFactory expressionFactory, CodeGeneratorOptions options)
        {
            return codeExpressions
                .OfType<CodeExpression>()
                .Select(parameter =>
                {
                    var parameterExpression = expressionFactory.GetExpression(parameter);
                    return parameterExpression.Evaluate(parameter, options);
                });
        }

        public static IEnumerable<string> GetParametersFromExpressions(this CodeParameterDeclarationExpressionCollection codeExpressions, IExpressionFactory expressionFactory, CodeGeneratorOptions options)
        {
            return codeExpressions
                .OfType<CodeParameterDeclarationExpression>()
                .Select(parameter =>
                {
                    var parameterExpression = expressionFactory.GetExpression(parameter);
                    return parameterExpression.Evaluate(parameter, options);
                });
        }

    }
}
