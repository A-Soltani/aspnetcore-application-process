import { Router } from 'aurelia-router';
import { PLATFORM } from 'aurelia-pal';

import { AppRoutes } from 'app-routes';

export class App {
  router: Router;

  configureRouter(config, router): void {
    config.title = 'Application Process';
    config.options.pushState = true;
    config.options.root = '/';
    config.map(AppRoutes);
    config.mapUnknownRoutes(PLATFORM.moduleName('core/not-found'));
    this.router = router;
  }

}

