import { FC } from "react";
import Body from "./Body";
import Footer from "./Footer";
import Header from "./Header";

const HomePage: FC = () => {
    return (
        <div className="App">
            <Header />
            <Body />
            <hr></hr>
            <Footer />
        </div>
    );
};

export default HomePage;