using System;
using System.Reflection;

namespace Grupo10.DistributedServices.Services.ApiREST.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}