using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Registration.Routes;

namespace SimpleWebsite.Handlers
{
    public class HandlerUrlPolicy : IUrlPolicy {
        public bool Matches(ActionCall call)
        {
            return call.HandlerType.Name.EndsWith("Handler");
        }

        public IRouteDefinition Build(ActionCall call)
        {
            var routeDefinition = call.ToRouteDefinition();
            routeDefinition.Append(call.HandlerType.Namespace.Replace(GetType().Namespace + ".", string.Empty).ToLower());
            routeDefinition.Append(call.HandlerType.Name.Replace("Handler", string.Empty).ToLower());
            return routeDefinition;
        }
    }
}