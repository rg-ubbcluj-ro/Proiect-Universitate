/*
public int Id { get; set; }
        public string? Email { get; set;}
        public int YearOfStudy {get; set;}
        public string? Specialization {get; set;}  

*/
export interface StudentItem {
    id?: number;
    email?: string;
    yearOfStudy?: number;
    specialization?: string;
}