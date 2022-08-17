export interface Ticket {
    id:number;
    userName:string;
    resolvedBy:string;
    subjectLine:string;
    questionDetails:string;
    status:string;
    dateOpened:Date;
    dateClosed:Date;
    resolution:string;
    favorited:boolean;

}
