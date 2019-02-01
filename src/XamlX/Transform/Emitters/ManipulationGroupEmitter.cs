using System.Reflection.Emit;
using XamlX.Ast;
using XamlX.TypeSystem;

namespace XamlX.Transform.Emitters
{
    public class ManipulationGroupEmitter : IXamlAstNodeEmitter
    {
        public bool Emit(IXamlAstNode node, XamlEmitContext context, IXamlXCodeGen codeGen)
        {
            if (!(node is XamlManipulationGroupNode group))
                return false;
            if (group.Children.Count == 0)
                codeGen.Generator.Emit(OpCodes.Pop);
            else
            {
                for (var c = 0; c < group.Children.Count; c++)
                {
                    if (c != group.Children.Count - 1)
                        codeGen.Generator.Emit(OpCodes.Dup);
                    context.Emit(group.Children[0], codeGen);
                }
            }

            return true;
        }
    }
}