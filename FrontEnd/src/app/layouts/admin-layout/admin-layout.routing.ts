import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { ActivityComponent } from 'src/app/pages/activity/activity.component';
import { CompletedHoursComponent } from 'src/app/pages/completed-hours/completed-hours.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'activity',    component: ActivityComponent},
    { path: 'hours',    component: CompletedHoursComponent},
    { path: 'edit/:id',    component: ActivityComponent},
    { path: 'delete/:id',    component: ActivityComponent}
];