using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using ReactiveUI;
using Zeroconf;

namespace BonjourBrowser.ViewModels
{
    class MainViewModel
    {
        public MainViewModel()
        {
            var browseSub = Observable.Create<string>(async (obs, cancel) =>
                                              {
                                                  await ZeroconfResolver.BrowseDomainsAsync(callback: (k, v) => obs.OnNext(k), cancellationToken: cancel);

                                                  obs.OnCompleted();
                                              });

            DiscoveredDomains = browseSub.Distinct().CreateCollection();


            
        }

        public IReactiveDerivedList<string> DiscoveredDomains { get; }


    }
}
