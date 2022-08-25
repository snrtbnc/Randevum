export default function({route,store,app,query,redirect}){

    
    if(route.name != 'index' && !store.state.user.isloggedin)
    {
       
        store.commit('setloginDialog',true);
    }

    if(route.name == 'superadmin' && store.state.user.role !='superadmin')
    {
        redirect('/')
    }
    
}