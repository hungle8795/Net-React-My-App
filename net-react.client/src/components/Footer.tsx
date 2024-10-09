import { FC } from "react";

const Footer: FC = () => {
    return (
        <div className="container-fluid d-flex justify-content-around">
            <hr></hr>
            <div className="col-10 col-10 col-md-4 col-lg-4 col-xl-4 text-start">
                <p>Category list</p>
                <div>
                    <a href="#fb" target="_blank">
                        <i className="fa-brands fa-facebook"></i>
                    </a>
                    <a href="#you" target="_blank">
                        <i className="fa-brands fa-youtube"></i>
                    </a>
                    <a href="#lin" target="_blank">
                        <i className="fa-brands fa-linkedin"></i>
                    </a>
                    <a href="#ins" target="_blank">
                        <i className="fa-brands fa-instagram"></i>
                    </a>
                </div>
            </div>
            <div className="d-flex justify-content-around col-10 col-10 col-md-6 col-lg-6 col-xl-6 left-0 right-0">
                <div className="col-10 col-10 col-md-5 col-lg-5 col-xl-5">
                    <h2>Links</h2>
                    <p>Rules</p>
                </div>
                <div className="col-10 col-10 col-md-5 col-lg-5 col-xl-5">
                    <h2>Contact</h2>
                    <p>Contact with us</p>
                </div>
            </div>
        </div>
    );
};

export default Footer;