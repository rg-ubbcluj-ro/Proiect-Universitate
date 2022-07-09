/* eslint-disable comma-dangle */
/* eslint-disable padded-blocks */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  navigator: Router;
  constructor(public authService: AuthenticationService, router: Router) {
    this.navigator = router;
  }

  get userRole() {
    return localStorage.getItem('role');
  }

  onLogoutClicked() {
    this.authService.logout();
    this.navigator.navigate(["/"]);
  }

  ngOnInit(): void {
  }

}
