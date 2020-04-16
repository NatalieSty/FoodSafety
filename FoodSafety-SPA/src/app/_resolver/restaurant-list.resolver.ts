import { Injectable } from '@angular/core';
import { Restuarant } from '../models/restuarants';
import { Resolve, Router, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { RestuarantService } from 'src/_services/restuarant.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable()
export class RestaurantListResolver implements Resolve<Restuarant> {
    pageNumber = 1;
    pageSize = 10;
    
    constructor(private restuarantService: RestuarantService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Restuarant> {
        return this.restuarantService.getRestuarants(this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                console.log('Problem retrieving data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
