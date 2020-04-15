import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { RestuarantService } from 'src/_services/restuarant.service';
import { Restuarant } from '../models/restuarants';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from 'src/_services/auth.service';

@Injectable()
export class FavoriteListResolver implements Resolve<Restuarant> {
    constructor(private restuarantService: RestuarantService, private router: Router, 
                private authService: AuthService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Restuarant> {
        return this.restuarantService.getFavorites(this.authService.decodedToken.nameid).pipe(
            catchError(error => {
                console.log('Problem retrieving favorite data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
