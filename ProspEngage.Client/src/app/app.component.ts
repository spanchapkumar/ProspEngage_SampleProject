import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserManagementService } from './Services/user-management.service';
import { UserManagementComponent } from './Components/usermanagement/usermanagement.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  imports: [UserManagementComponent,HttpClientModule ],
  providers:[HttpClientModule,UserManagementService],
  template: `
  <app-usermanagement></app-usermanagement>
`,
  styleUrls: ['./app.component.css'] 
})
export class AppComponent {
  title = 'ProspEngage.Client';
}
