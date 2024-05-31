import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {QuanlyvanbanRoutingModule} from './quanlyvanban-routing.module';
import {QuanlyvanbanComponent} from './quanlyvanban.component';
import { PaginatorModule } from 'primeng/paginator';
import { TableModule } from 'primeng/table'; 
import { ButtonModule } from 'primeng/button';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { TagModule } from 'primeng/tag';
import { CheckboxModule } from 'primeng/checkbox';
import { TabsModule} from 'ngx-bootstrap/tabs';

@NgModule({
    declarations: [QuanlyvanbanComponent],
    // imports: [AppSharedModule, QuanlyvanbanRoutingModule, TableModule]
    imports: [
        PaginatorModule,
        TableModule,
        ButtonModule,
        AutoCompleteModule,
        TagModule,
        CheckboxModule,
        TabsModule.forRoot(),
        AppSharedModule, QuanlyvanbanRoutingModule
    ], 
})
export class QuanlyvanbanModule {}