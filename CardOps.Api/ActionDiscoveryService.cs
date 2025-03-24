using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CardOps.Core.Actions;
using CardOps.Core.Models;

namespace CardOps.Api
{
    internal class ActionDiscoveryService
    {
        private static readonly ICardAction[] availableActions = GetAvailableActions().ToArray();

        public static IEnumerable<ICardAction> AllAvailableActions => availableActions;

        public static IEnumerable<ICardAction> GetAllowedActions(CardDetails cardDetails)
        {
            return availableActions.Where(aa => aa.IsAllowed(cardDetails));
        }

        private static IEnumerable<ICardAction> GetAvailableActions()
        {
            var plugins = Environment.GetEnvironmentVariable("ActionPlugins");

            if (string.IsNullOrWhiteSpace(plugins))
            {
                return [];
            }

            return plugins.Split(['|'], StringSplitOptions.RemoveEmptyEntries).SelectMany(static plugin =>
            {
                try
                {
                    
                    return Assembly.LoadFrom(plugin).GetTypes().Where(type => typeof(ICardAction).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract).Select(type => (ICardAction)Activator.CreateInstance(type)!);
                }
                catch
                {
                    return [];
                }
            });
        }
    }
}
