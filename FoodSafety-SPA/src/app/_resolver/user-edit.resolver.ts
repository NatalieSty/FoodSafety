import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { User } from '../models/User';
import { UserService } from 'src/_services/user.service';
import { AuthService } from 'src/_services/auth.service';
import { AlertifyService } from 'src/_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class UserEditResolver implements Resolve<User> {
    constructor(private userService: UserService, private router: Router,
                private alert: AlertifyService, private authService: AuthService) {}

    // go to user service to get the user. and the rest is to catch error.
    // when using resolve, this automatically subscribes to the method
    // use pipe to catch error: alert error and go back to members page
    // of: an observable of null
    resolve(route: ActivatedRouteSnapshot): Observable<User> {
        return this.userService.getUser(this.authService.decodedToken.nameid).pipe(
            catchError(error => {
                this.alert.error('Problem retrieving your data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}