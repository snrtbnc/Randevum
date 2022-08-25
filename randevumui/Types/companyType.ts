export interface company 
    {
        pictureurl: string;

        name: string;

        shortdesc:string;

        phonenumber: phone;

        address: address;

    }

    export interface phone
    {
        countrycode: string;

        citycode: string;

        phonenumber: string;
    }

    export interface address
    {
        country: string;

        location: location;
        
        citycode: number;

        cityname: string;     

        district: string;

        detail: string;


    }

    export interface location
    {
       latitude: number; 
       longitude: number;
    }