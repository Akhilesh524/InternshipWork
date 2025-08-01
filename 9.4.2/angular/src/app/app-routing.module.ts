import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { AppComponent } from './app.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { FounderComponent } from './founder/founder.component';
import { ManagerComponent } from './manager/manager.component';


@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: AppComponent,
        children: [
          {
            path: 'home',
            loadChildren: () =>
              import('./home/home.module').then((m) => m.HomeModule),
            canActivate: [AppRouteGuard],
          },
          {
            path: 'about',
            loadChildren: () =>
              import('./about/about.module').then((m) => m.AboutModule),
            canActivate: [AppRouteGuard],
          },
          {
            path: 'users',
            loadChildren: () =>
              import('./users/users.module').then((m) => m.UsersModule),
            data: { permission: 'Pages.Users' },
            canActivate: [AppRouteGuard],
          },
          {
            path: 'roles',
            loadChildren: () =>
              import('./roles/roles.module').then((m) => m.RolesModule),
            data: { permission: 'Pages.Roles' },
            canActivate: [AppRouteGuard],
          },
          {
            path: 'tenants',
            loadChildren: () =>
              import('./tenants/tenants.module').then((m) => m.TenantsModule),
            data: { permission: 'Pages.Tenants' },
            canActivate: [AppRouteGuard],
          },
          {
            path: 'update-password',
            loadChildren: () =>
              import('./users/users.module').then((m) => m.UsersModule),
            canActivate: [AppRouteGuard],
          },

          // ✅ Your new Employee List route
          {
            path: 'employees',
            component: EmployeeListComponent,
            canActivate: [AppRouteGuard] // Optional if protected
          },

          {
            path: 'founder',
            component:FounderComponent,
            canActivate:[AppRouteGuard]
          },
          {
            path: 'manager',
            component:ManagerComponent,
            canActivate:[AppRouteGuard]
          }
        ],
      },
    ]),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}




