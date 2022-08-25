export default function ({ $axios, app, store }) {
    $axios.onRequest(config => {
      if (store.state.token) {
        config.headers.common['Authorization'] = "Bearer " +store.state.token
      }
    })
  }