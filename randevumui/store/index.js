import Vuex from "vuex";

const createStore = () => {
    return new Vuex.Store({
        state: {
            CompanyList: [],
            searchValue: "",
            PageResult: [],
            pageNumber: 1,
            user: { isloggedin: true, role: "superadmin", name: "Osman" },
            token: "",
            loginDialog: false,
            snackbarInfo: {
                color: 'success',
                mode: '',
                value: false,
                text: 'Lokasyon Seçildi',
                timeout: 3000,
                x: null,
                y: 'bottom',
            },
        },

        mutations: {
            setCompanyList(state, CompanyList) {
                state.CompanyList = CompanyList;
            },

            SetSearchValue(state, searchValue) {
                state.searchValue = searchValue;
            },

            setPage(state, pageNumber) {
                state.pageNumber = pageNumber;
            },

            setloginDialog(state, value) {
                state.loginDialog = value;
            },

            setToken(state, token) {
                state.token = token;
                localStorage.setItem('token', token);
            },
            setSnackbarInfo(state, snackbarInfo) {
                state.snackbarInfo = snackbarInfo;
            }


        },
        actions: {
            async setCompanyList(vuexContext, data) {
                vuexContext.commit('setCompanyList', data);
            }
        },
        getters: {
            CompanyList(state) {
                return state.CompanyList
            },


            PageResult(state) {
                return state.CompanyList.filter(x => x.name.includes(state.searchValue))
                    .slice((state.pageNumber - 1) * 12, state.pageNumber * 12)
            },

            loginDialog(state) {
                return state.loginDialog;
            },

            userInfo(state) {
                return state.user;
            },
            getSnackbarInfo(state) {
                return state.snackbarInfo;
            }

        }

    });
}

export default createStore