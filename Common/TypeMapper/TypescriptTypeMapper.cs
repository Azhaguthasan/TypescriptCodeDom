using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TypescriptCodeDom.Common.TypeMapper
{
    public class TypescriptTypeMapper : ITypescriptTypeMapper
    {
        private readonly Dictionary<string, string> _typeMap;
        private readonly Regex _baseTypeRegex = new Regex(@"(?<TypeName>([a-zA-Z]+[0-9.]*)+)");
        private readonly Regex _arrayRegex = new Regex(@"(?<TypeName>([a-zA-Z]+[0-9.]*)+)(?<TypeArguments>[`0-9]*)(\[(?<JaggedRank>\]\[)*|(?<DimensionalRank>,)*\])+");

        public TypescriptTypeMapper()
        {
            _typeMap = new Dictionary<string, string>();            

            AddAllKnownTypes();
        }

        private void AddAllKnownTypes()
        {
            _typeMap[typeof(int).Name] = "number";
            _typeMap[typeof(uint).Name] = "number";
            _typeMap[typeof(long).Name] = "number";
            _typeMap[typeof(ulong).Name] = "number";
            _typeMap[typeof(short).Name] = "number";
            _typeMap[typeof(ushort).Name] = "number";
            _typeMap[typeof(float).Name] = "number";
            _typeMap[typeof(double).Name] = "number";
            _typeMap[typeof(string).Name] = "string";
            _typeMap[typeof(bool).Name] = "boolean";
            _typeMap[typeof(void).Name] = "void";
            _typeMap[typeof(object).Name] = "any";
            _typeMap[typeof(DateTime).Name] = "Date";
            _typeMap["System.Collections.Generic.List"] = "Array";
            _typeMap["System.Collections.Generic.IList"] = "Array";
            _typeMap["System.Collections.Generic.IEnumerable"] = "Array";
            _typeMap["System.Collections.IEnumerable"] = "Array";
            _typeMap["System.Array"] = "Array";
        }

        public string GetTypeOutput(CodeTypeReference type)
        {
            if (!_baseTypeRegex.IsMatch(type.BaseType))
                throw new ArgumentException("Type mismatch");

            var baseTypeName = _baseTypeRegex
                .Match(type.BaseType)
                .Groups["TypeName"]
                .Captures[0]
                .Value;

            var typeOutputString = TranslateType(baseTypeName);

            if (type.TypeArguments.Count > 0)
                typeOutputString = AddTypeArguments(type, typeOutputString);

            if (_arrayRegex.IsMatch(type.BaseType))
                typeOutputString = GetArrayType(type.BaseType, typeOutputString);
                        
            return typeOutputString;
        }

        private string AddTypeArguments(CodeTypeReference type, string typeOutputString)
        {
            var typeArguments = type.TypeArguments
                .OfType<CodeTypeReference>()
                .Select(GetTypeOutput);

            return $"{typeOutputString}<{string.Join(", ", typeArguments)}>";
        }

        private string TranslateType(string baseTypeName)
        {
            return _typeMap.ContainsKey(baseTypeName) ? _typeMap[baseTypeName] : baseTypeName;
        }

        private string GetArrayType(string baseType, string actualTypeName)
        {
            var matches = _arrayRegex.Match(baseType);
            var jaggedcount = matches.Groups["JaggedRank"].Captures.Count;
            var dimensionalArrayCount = matches.Groups["DimensionalRank"].Captures.Count;
            if (jaggedcount > 0)
            {
                return GetArrayString(actualTypeName, jaggedcount + 1);
            }
            if (dimensionalArrayCount > 0)
            {
                return GetArrayString(actualTypeName, dimensionalArrayCount + 1);
            }

            return GetArrayString(actualTypeName, 1);
        }

        private string GetArrayString(string baseType, int count)
        {
            return count == 0 ? baseType : $"Array<{GetArrayString(baseType, count-1)}>";
        }
    }
}
