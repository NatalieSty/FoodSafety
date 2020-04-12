import { Violation } from './violation';
import { Inspection } from './inspection';

export class Restuarant{
    businessID: string;
    name: string;
    description: string;
    address: string;
    city: string;
    zipCode: number;
    phone: string;
    longtitude: number;
    latitude: number;
    violations: Violation[];
    inspections: Inspection[];
    grade: number;
}