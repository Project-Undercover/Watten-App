import {
  FETCH_USERS_SUCCESS,
  FETCH_USER_PROFILE_SUCCESS,
  FILTER_USERS,
  FETCH_USER_HOME_DATA_SUCCESS,
  FETCH_USER_CHILDREN_SUCCESS,
  FETCH_ROLES_SUCCESS,
} from "../constants/actionTypes";
const initialState = {
  users: [],
  searchedUsers: [],
  userProfile: {},
  userHomeData: {},
  userChildren: [],
  roles: [],
  error: null,
};

const usersReducer = (state = initialState, action) => {
  switch (action.type) {
    case FETCH_USERS_SUCCESS:
      return {
        ...state,
        users: action.payload,
        searchedUsers: action.payload,
      };
    case FETCH_USER_PROFILE_SUCCESS:
      return {
        ...state,
        userProfile: action.payload,
      };
    case FETCH_USER_HOME_DATA_SUCCESS:
      return {
        ...state,
        userHomeData: action.payload,
      };
    case FETCH_USER_CHILDREN_SUCCESS:
      return {
        ...state,
        userChildren: action.payload,
      };
    case FETCH_ROLES_SUCCESS:
      return {
        ...state,
        roles: action.payload,
      };
    case FILTER_USERS:
      const searchInput = action.payload.toLowerCase();
      const filteredUsers = state.users.filter((user) => {
        const { mobileNumber, firstName, lastName } = user;
        return (
          !searchInput ||
          mobileNumber.includes(searchInput) ||
          firstName.includes(searchInput) ||
          lastName.includes(searchInput)
        );
      });
      return {
        ...state,
        searchedUsers: filteredUsers,
      };

    default:
      return state;
  }
};

export default usersReducer;
