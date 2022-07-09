// import {ResourceLoader} from '@angular/compiler';
import {Component, OnInit} from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import {Router} from '@angular/router';
//import { RegisterComponent } from 'src/app/auth/register/register.component';
import {AuthenticationService} from 'src/app/services/authentication.service';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  constructor(private formBuilder: FormBuilder, private _snackBar: MatSnackBar,
     public authService: AuthenticationService,
     router : Router) {
      if (this.authService.isAuthenticated()) {
        router.navigate(['Student']);
      }
      }

  loginForm = this.formBuilder.group({
    Email: ['', [Validators.required]],
    Password: ['', [Validators.required, Validators.minLength(4)]],
  });
  get email() {
  return this.loginForm.get('email');
  }
  get password() {
  return this.loginForm.get('password');
  }

  onLoginClicked() {
    this.authService.login(this.loginForm.value).subscribe((tokenObj) => {
      localStorage.setItem('token', tokenObj.token);
      this._snackBar.open('Login successful!', 'Ok', {
        verticalPosition: 'top',
        duration: 4 * 1000,
      });
      // this.loginForm.reset();
      window.location.reload();
    }, (error) => {
      console.log(error);
      this._snackBar.open('Login failed: ' + error.error, 'Ok', {
        verticalPosition: 'top',
        duration: 4 * 1000,
      });
    });
  }

  ngOnInit(): void {
  }
}
