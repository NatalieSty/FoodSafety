import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Restuarant } from 'src/app/models/restuarants';

@Injectable({
    providedIn: 'root'
})

export class RestuarantService {
    baseUrl = "http://localhost:5000/";

    constructor(private http: HttpClient) {}

    getRestuarants(): Observable<Restuarant[]> {
        return this.http.get<Restuarant[]>(this.baseUrl + 'api/' + 'restuarants');
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