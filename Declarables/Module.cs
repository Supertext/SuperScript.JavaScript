namespace SuperScript.JavaScript.Declarables
{
    public class Module
    {
        public Module(string moduleNamespace, params DeclarationBase[] declarations)
        {
            foreach (var declaration in declarations)
            {
                declaration.Name = moduleNamespace + "." + declaration.Name;

                SuperScript.Declarations.AddDeclaration<DeclarationBase>(declaration);
            }
        }
    }
}