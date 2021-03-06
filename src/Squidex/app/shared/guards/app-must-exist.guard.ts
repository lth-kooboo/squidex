/*
 * Squidex Headless CMS
 *
 * @license
 * Copyright (c) Squidex UG (haftungsbeschränkt). All rights reserved.
 */

import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';

import { AppsState } from './../state/apps.state';

@Injectable()
export class AppMustExistGuard implements CanActivate {
    constructor(
        private readonly appsState: AppsState,
        private readonly router: Router
    ) {
    }

    public canActivate(route: ActivatedRouteSnapshot): Observable<boolean> {
        const appName = route.params['appName'];

        const result =
            this.appsState.select(appName)
                .do(dto => {
                    if (!dto) {
                        this.router.navigate(['/404']);
                    }
                }).map(a => !!a);

        return result;
    }
}