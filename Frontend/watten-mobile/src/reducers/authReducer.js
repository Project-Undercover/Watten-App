import {
  LOGIN_SUCCESS,
  LOGIN_REQUEST,
  LOGIN_FAILURE,
  VERIFY_SUCCESS,
  LOGOUT_SUCCESS,
  CHANGE_LANG_SUCCESS,
  USER_IN_STORAGE_SUCCESS,
} from "../constants/actionTypes";
import { storeData } from "../utils/storage";

const initialState = {
  isLoggedIn: false,
  user: {},
  isLoading: false,
  requestId: "",
  language: "he",
  error: {},
};

const authReducer = (state = initialState, action) => {
  switch (action.type) {
    case LOGIN_REQUEST:
      return {
        ...state,
        isLoading: true,
        error: null,
      };
    case LOGIN_SUCCESS:
      return {
        ...state,
        requestId: action.payload.requestId,
        user: { ...state.user, phone: action.payload.phone },
        isLoggedIn: true,
        isLoading: false,
        error: null,
      };
    case VERIFY_SUCCESS:
      storeData({ user: action.payload, token: action.payload?.jwt });
      return {
        ...state,
        user: { ...state.user, ...action.payload },
        // isLoading: false,
        error: null,
      };
    case LOGIN_FAILURE:
      return {
        ...state,
        isLoading: false,
        error: action?.payload,
      };
    case CHANGE_LANG_SUCCESS:
      return {
        ...state,
        language: action.payload,
      };
    case USER_IN_STORAGE_SUCCESS:
      return {
        ...state,
        user: action.payload,
        isLoggedIn: true,
      };

    case LOGOUT_SUCCESS:
      return {
        ...initialState,
      };
    default:
      return state;
  }
};

export default authReducer;
