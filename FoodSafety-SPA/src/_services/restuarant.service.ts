import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Restuarant } from 'src/app/models/restuarants';
import { PaginatedResult } from 'src/app/models/pagination';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})

export class RestuarantService {
    baseUrl = "http://localhost:5000/";

    constructor(private http: HttpClient) {}

    getRestuarants(page?, itemsPerPage?): Observable<PaginatedResult<Restuarant[]>> {
        const paginatedResult: PaginatedResult<Restuarant[]> = new PaginatedResult<Restuarant[]>();
        let params = new HttpParams();

        if (page != null && itemsPerPage != null) {
            params = params.append('pageNumber', page);
            params = params.append('pageSize', itemsPerPage);
        }

        return this.http.get<Restuarant[]>(this.baseUrl + 'api/' + 'restuarants', { observe: 'response', params})
            .pipe(
                map(response => {
                    paginatedResult.result = response.body;
                    if (response.headers.get('Pagination') != null) {
                    paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
                    }
                    return paginatedResult;
                })
            );
    }

    getFavorites(userId) {
        return this.http.get<Restuarant[]>(this.baseUrl + 'api/' + 'Favourites/' + userId);
    }

    addFavorite(businessID, userId) {
        //"{userId}/Like/{restuarantId}"
        return this.http.post(this.baseUrl + 'api/' + 'restuarants/' + userId + '/Like/' + businessID, {});
    }

    removeFavorite(businessID, userId) {
        //"{userId}/Like/{restuarantId}"
        return this.http.delete(this.baseUrl + 'api/' + 'Favourites/' + userId + '/Unlike/' + businessID, {});
    }
}