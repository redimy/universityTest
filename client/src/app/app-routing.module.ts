import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdministrationComponent } from './administration/administration.component';
import { AssignmentsComponent } from './assignments/assignments.component';
import { GradeComponent } from './grade/grade.component';
import { GroupsComponent } from './groups/groups.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'groups', component: GroupsComponent, canActivate: [AuthGuard]},
  {path: 'assignments', component: AssignmentsComponent, canActivate: [AuthGuard]},
  {path: 'grades', component: GradeComponent, canActivate: [AuthGuard]},
  {path: 'admin', component: AdministrationComponent, canActivate: [AuthGuard]},
  {path: '**', component: HomeComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
