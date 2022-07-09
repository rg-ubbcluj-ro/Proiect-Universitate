import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = "University Angular App"

  constructor(private formBuilder: FormBuilder, private _snackBar: MatSnackBar,
    public authService: AuthenticationService) { }

  loginForm = this.formBuilder.group({
    Email: ['', [Validators.required]],
    Password: ['', [Validators.required, Validators.minLength(4)]],
  });
  get isAuth() {
    return !!this.authService.isAuthenticated();
  }
  get email() {
    return this.loginForm.get('email');
  }
  get password() {
    return this.loginForm.get('password');
  }

  onLoginClicked() {
    this.authService.login(this.loginForm.value).subscribe((tokenObj) => {
      localStorage.setItem('token', tokenObj.token);
      localStorage.setItem('role', tokenObj.role);
      this._snackBar.open('Login successful!', 'Ok', {
        verticalPosition: 'top',
        duration: 4 * 1000,
      });

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
