import Vue from "vue";
import * as VueGoogleMaps from "vue2-google-maps-withscopedautocomp";

Vue.use(VueGoogleMaps, {
  load: {
    key: "AIzaSyAZoCBhKZtO6Tn-szEHcyNgxKj2us-vNYo",
    libraries: "places"
  }
});
