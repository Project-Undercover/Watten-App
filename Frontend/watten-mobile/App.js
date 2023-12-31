import { View, StatusBar, I18nManager } from "react-native";
import { Provider } from "react-redux";
import { AlertsContextProvider } from "./src/context/AlertsContext";
import { TailwindProvider } from "tailwindcss-react-native";
import { ToastProvider } from "react-native-toast-notifications";
import { useEffect } from "react";
import store from "./src/stores/configureStore";
import Navigation from "./src/navigation";
import { useFonts } from "expo-font";
import i18next from "./src/utils/i18n";
import NetInfo from "@react-native-community/netinfo";
import { LoadingContextProvider } from "./src/context/LoadingContext";
import "moment/locale/he";
import "moment/locale/ar";
export default function App() {
  const [fontsLoaded] = useFonts({
    "Cairo-Bold": require("./src/assets/fonts/Cairo-Medium.ttf"),
    "Cairo-Regular": require("./src/assets/fonts/Cairo-Regular.ttf"),
    "Rubik-Bold": require("./src/assets/fonts/Rubik-Bold.ttf"),
    "Rubik-Medium": require("./src/assets/fonts/Rubik-Medium.ttf"),
    "Rubik-Regular": require("./src/assets/fonts/Rubik-Regular.ttf"),
    "Rubik-SemiBold": require("./src/assets/fonts/Rubik-SemiBold.ttf"),
  });

  // useEffect(() => {
  //   const unsubscribe = NetInfo.addEventListener((state) => {
  //     console.log(state);
  //     if (!state.isConnected) {
  //       console.log("Unable to connect");
  //       // Handle no internet connection globally
  //       // e.g., show a banner, disable certain features, etc.
  //     } else {
  //       console.log("connected");
  //     }
  //   });

  //   return () => {
  //     unsubscribe();
  //   };
  // }, []);
  if (!fontsLoaded) {
    return null;
  }

  return (
    <Provider store={store}>
      <TailwindProvider>
        <ToastProvider>
          <LoadingContextProvider>
            <AlertsContextProvider>
              <View style={{ flex: 1 }}>
                <Navigation />
              </View>
            </AlertsContextProvider>
          </LoadingContextProvider>
        </ToastProvider>
      </TailwindProvider>
    </Provider>
  );
}
