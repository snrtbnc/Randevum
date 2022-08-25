<template>
  <div>
    <div>
      <h2>İşletmenizin Lokasyonunu Seçiniz</h2>
      <label>
        <gmap-autocomplete  
        @place_changed="addressEntered" 
        >
          <template v-slot:input="slotProps">
            <v-text-field
            style="{vertical-align: middle}" 
            outlined
            prepend-inner-icon="mdi-map-marker"
            label="Ara"
            placeholder="Lokasyon Ara"
            ref="input"
            v-on:listeners="slotProps.listeners"
            v-on:attrs="slotProps.attrs"
              ></v-text-field>
          </template>
        </gmap-autocomplete>
      </label>
      <br />
    </div>
    <br />
    
    <GmapMap
      @click="locationSelected"
      :center="center"
      :zoom="zoom"
      map-type-id="terrain"
      style="width: 100%; height: 300px"
      :options="{
      zoomControl: true,
      mapTypeControl: false,
      scaleControl: false,
      streetViewControl: false,
      rotateControl: false,
      fullscreenControl: true,
      disableDefaultUI: false,
      draggable:true
      }"
    >
      <GmapMarker
        :key="index"
        v-for="(m, index) in markers"
        :position="m.position"
        :clickable="true"
        :draggable="true"
        @dragend="locationSelected"
        @click="locationSelected"
      />
    </GmapMap>
    
  </div>
</template>

<script>
export default {
  name: "GoogleMap",
  data() {
    return {
    
      center: { lat: 41.508, lng: 29.587 },
      markers: [],
      places: [],
      currentPlace: null,
      zoom:7,
      searchZoom:15,
      
    };
  },

  mounted() {
    this.geolocate();
  },

  methods: {
    // receives a place object via the autocomplete component
    addressEntered(selectedLocation)
    {
      this.zoom = this.searchZoom;
        this.center = {
          lat: selectedLocation.geometry.location.lat(),
          lng: selectedLocation.geometry.location.lng()
        };   
    },
    
    locationSelected(value) {
      this.markers = [];
      const marker = {
        lat: value.latLng.lat(),
        lng: value.latLng.lng()
      };

      this.markers.push({ position: marker });
      this.snackbar=true;
      this.$emit('location',marker)
    },
    geolocate: function() {
      navigator.geolocation.getCurrentPosition(position => {
        this.center = {
          lat: position.coords.latitude,
          lng: position.coords.longitude
        };
      });
    }
  }
};
</script>

<style>
</style>