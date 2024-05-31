import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DonvikhamchuabenhComponent } from './donvikhamchuabenh.component';

const routes: Routes = [{
    path: '',
    component: DonvikhamchuabenhComponent ,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class DonvikhamchuabenhRoutingModule {}
