/*
Author: Jingwen Zhang
Partner: -Na-
Date: 2021/10/24
Course: CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Jingwen Zhang - This work may not be copied for use in Academic Coursework.

I, Jingwen Zhang, certify that I wrote this code from scratch and did not copy it in part or whole from
another source. Any references used in the completion of the assignment are cited in my README file.
*/

class AvailabilityTracker {



    constructor() {

    }

    /**
     * Draw the three buttons for applicants to set up
     * @param {any} app
     * @param {any} userID
     */
    button_draw(app, userID) {
        // draw button
        let Graphics = PIXI.Graphics;
        let buttonSave = new Graphics();
        buttonSave.lineStyle(2, 0xF4A460, 1);
        buttonSave.beginFill(0xF5DEB3);
        buttonSave.drawRect(0, 0, 120, 40);
        buttonSave.endFill();
        buttonSave.x = 1450;
        buttonSave.y = 105;
        buttonSave.interactive = true;
        buttonSave.buttonMode = true;
        app.stage.addChild(buttonSave);
        buttonSave.on('mouseup', function (e) {

            var path = "/Availabilities/SetSchedule";
            var data = { userID: userID };

            $(document).ajaxSend(function () {
                $("#overlay").fadeIn(1000);
            });

            $.post(path, data)
                .done(function () {
                    setTimeout(function () {
                        $("#overlay").fadeOut(1000);
                    }, 500);

                    setTimeout(function () {
                        window.location.reload();
                    }, 2500);

                })
                .fail(function () {
                    alert('Failed to Send Data to set');
                });
        });

        let Text = PIXI.Text;
        // draw button text
        let style3 = new PIXI.TextStyle({
            fontSize: 28,
            fill: 0xFF6347,
        });
        let save = new Text("Save", style3);
        app.stage.addChild(save);
        save.position.set(1480, 109);

        // draw button
        let buttonClear = new Graphics();
        buttonClear.lineStyle(2, 0xF4A460, 1);
        buttonClear.beginFill(0xF5DEB3);
        buttonClear.drawRect(0, 0, 120, 40);
        buttonClear.endFill();
        buttonClear.x = 1450;
        buttonClear.y = 205;
        buttonClear.interactive = true;
        buttonClear.buttonMode = true;
        app.stage.addChild(buttonClear);
        buttonClear.on('mouseup', function (e) {

            var path = "/Availabilities/ClearPending";
            var data = { userID: userID };

            $(document).ajaxSend(function () {
                $("#overlay").fadeIn(1000);
            });

            $.post(path, data)
                .done(function () {
                    setTimeout(function () {
                        $("#overlay").fadeOut(1000);
                    }, 500);

                    setTimeout(function () {
                        window.location.reload();
                    }, 2500);

                })
                .fail(function () {
                    alert('Failed to Send Data to Clear');
                });

        });

        let clear = new Text("Clear", style3);
        app.stage.addChild(clear);
        clear.position.set(1480, 209);

        let style6 = new PIXI.TextStyle({
            fontSize: 15,
            fill: 0xF4A460,
        });
        let m3 = new Text("Click to clear all", style6);
        app.stage.addChild(m3);
        m3.position.set(1450, 250);

        let m4 = new Text("unsaved changes", style6);
        app.stage.addChild(m4);
        m4.position.set(1450, 270);


        // draw button
        let buttonReset = new Graphics();
        buttonReset.lineStyle(2, 0xFF0000, 1);
        buttonReset.beginFill(0xF5DEB3);
        buttonReset.drawRect(0, 0, 120, 40);
        buttonReset.endFill();
        buttonReset.x = 1450;
        buttonReset.y = 325;
        buttonReset.interactive = true;
        buttonReset.buttonMode = true;
        app.stage.addChild(buttonReset);
        buttonReset.on('mouseup', function (e) {
            var path = "/Availabilities/ResetSchedule";
            var data = { userID: userID };

            $(document).ajaxSend(function () {
                $("#overlay").fadeIn(2000);
            });

            $.post(path, data)
                .done(function () {
                    setTimeout(function () {
                        $("#overlay").fadeOut(1000);
                    }, 500);

                    setTimeout(function () {
                        window.location.reload();
                    }, 3000);

                })
                .fail(function () {
                    alert('Failed to Send Data to reset');
                });
        });

        // draw button text    
        let style4 = new PIXI.TextStyle({
            fontSize: 28,
            fill: 0xFF0000,
        });
        let reset = new Text("Reset", style4);
        app.stage.addChild(reset);
        reset.position.set(1478, 328);

        let style5 = new PIXI.TextStyle({
            fontSize: 16,
            fill: 0xFF0000,
        });
        let resetM = new Text("Click to clear all", style5);
        app.stage.addChild(resetM);
        resetM.position.set(1450, 369);

        let resetN = new Text("scheduled time", style5);
        app.stage.addChild(resetN);
        resetN.position.set(1450, 389);


    }

    /**
     * Draw the name of current availability page for admin and professor
     * @param {any} app
     * @param {any} name
     */
    name_draw(app, name) {
        let Text = PIXI.Text;
        // draw button text
        let style3 = new PIXI.TextStyle({
            fontSize: 22,
            fill: 0xFF6347,
        });
        let text = new Text("Availability of", style3);
        app.stage.addChild(text);
        text.position.set(1450, 109);
        let nametag = new Text(name, style3);
        app.stage.addChild(nametag);
        nametag.position.set(1450, 139);
    }

    /**
     * Draw the titles of weekdays and time periods
     * @param {any} app
     */
    slots_draw(app) {
        // draw week day names
        let Graphics = PIXI.Graphics;
        let Text = PIXI.Text;
        let style = new PIXI.TextStyle({
            fontFamily: "Arial",
            fontSize: 28,
            fill: "white",
            stroke: '#0000FF',
            strokeThickness: 1,
            dropShadow: true,
            dropShadowColor: "#F0F8FF",
            dropShadowBlur: 4,
            dropShadowAngle: Math.PI / 6,
            dropShadowDistance: 6,
        });
        let Monday = new Text("Monday", style);
        Monday.x = 250;
        Monday.y = 70;
        app.stage.addChild(Monday);
        let Tuesday = new Text("Tuesday", style);
        Tuesday.x = 450;
        Tuesday.y = 70;
        app.stage.addChild(Tuesday);
        let Wednesday = new Text("Wednesday", style);
        Wednesday.x = 630;
        Wednesday.y = 70;
        app.stage.addChild(Wednesday);
        let Thursday = new Text("Thursday", style);
        Thursday.x = 840;
        Thursday.y = 70;
        app.stage.addChild(Thursday);
        let Friday = new Text("Friday", style);
        Friday.x = 1060;
        Friday.y = 70;
        app.stage.addChild(Friday);

        // draw horizontal time lines
        for (let i = 0; i < 13; i++) {
            let line = new Graphics();
            line.lineStyle(2, 0xFFFFFF, 1);
            line.moveTo(120, 90 + i * 56);
            line.lineTo(1240, 90 + i * 56);
            line.x = 32;
            line.y = 32;
            app.stage.addChild(line);
        }

        // draw time names
        let style2 = new PIXI.TextStyle({
            fontFamily: "Arial",
            fontSize: 22,
            fill: "white",
        });
        let time1 = new Text("8:00 am", style2);
        app.stage.addChild(time1);
        time1.position.set(1300, 105);
        let time2 = new Text("9:00 am", style2);
        app.stage.addChild(time2);
        time2.position.set(1300, 163);
        let time3 = new Text("10:00 am", style2);
        app.stage.addChild(time3);
        time3.position.set(1300, 219);
        let time4 = new Text("11:00 am", style2);
        app.stage.addChild(time4);
        time4.position.set(1300, 275);
        let time5 = new Text("00:00 pm", style2);
        app.stage.addChild(time5);
        time5.position.set(1300, 331);
        let time6 = new Text("1:00 pm", style2);
        app.stage.addChild(time6);
        time6.position.set(1300, 387);
        let time7 = new Text("2:00 pm", style2);
        app.stage.addChild(time7);
        time7.position.set(1300, 443);
        let time8 = new Text("3:00 pm", style2);
        app.stage.addChild(time8);
        time8.position.set(1300, 499);
        let time9 = new Text("4:00 pm", style2);
        app.stage.addChild(time9);
        time9.position.set(1300, 555);
        let time10 = new Text("5:00 pm", style2);
        app.stage.addChild(time10);
        time10.position.set(1300, 611);
        let time11 = new Text("6:00 pm", style2);
        app.stage.addChild(time11);
        time11.position.set(1300, 667);
        let time12 = new Text("7:00 pm", style2);
        app.stage.addChild(time12);
        time12.position.set(1300, 723);
        let time13 = new Text("8:00 pm", style2);
        app.stage.addChild(time13);
        time13.position.set(1300, 779);

    }

    /**
     * Draw the slots for applicants
     * @param {any} app
     * @param {any} jsPreSlots
     * @param {any} userID
     */
    setslots_draw(app, jsPreSlots, userID) {

        let Graphics = PIXI.Graphics;
        // draw slots
        for (let j = 0; j < 5; j++) {

            for (let i = 0; i < 48; i++) {

                if (jsPreSlots[i + j * 48]) // there is slot selected
                {
                    let rectangle = new Graphics();
                    rectangle.beginFill(0xd8bfd8);
                    rectangle.drawRect(0, 0, 120, 14);
                    rectangle.endFill();
                    rectangle.x = 240 + 200 * j;
                    rectangle.y = 120 + 14 * i;
                    rectangle.interactive = false;
                    rectangle.buttonMode = false;
                    app.stage.addChild(rectangle);
                }

                else {
                    let rectangle = new Graphics();
                    rectangle.beginFill(0x66CCFF);
                    rectangle.drawRect(0, 0, 120, 14);
                    rectangle.endFill();
                    rectangle.x = 240 + 200 * j;
                    rectangle.y = 120 + 14 * i;
                    rectangle.interactive = true;
                    rectangle.buttonMode = true;
                    app.stage.addChild(rectangle);

                    // click and drag event and handler
                    var before_x;
                    var before_y;
                    rectangle.on('mousedown', function (e) {
                        console.log('Picked up');
                        before_x = rectangle.x;
                        before_y = rectangle.y;
                        rectangle.dragging = false;
                    });

                    rectangle.on('mousemove', function (e) {
                        console.log('Dragging');
                        rectangle.dragging = true;
                    });

                    rectangle.on('mouseup', function (e) {
                        console.log('Moving');

                        let Text = PIXI.Text;
                        let style6 = new PIXI.TextStyle({
                            fontSize: 22,
                            fill: 0xF4A460,
                        });

                        // drag
                        if (rectangle.dragging) {
                            var after_x = e.data.global.x;
                            var after_y = e.data.global.y;

                            var m = (after_y - before_y) / 14;
                            var sum = 0;
                            for (let n = 0; n < m; n++) {
                                let rectangle_new2 = new Graphics();
                                rectangle_new2.beginFill(0xd8bfd8);
                                rectangle_new2.drawRect(0, 0, 120, 14);
                                rectangle_new2.endFill();
                                rectangle_new2.x = before_x;
                                rectangle_new2.y = before_y + 14 * n;
                                rectangle_new2.interactive = false;
                                rectangle_new2.buttonMode = false;
                                app.stage.addChild(rectangle_new2);
                                sum++;
                            }

                            var path = "/Availabilities/ReceiveIndex";
                            var data = { before_x: before_x, before_y: before_y, m: sum, userID: userID };

                            $.post(path, data)
                                .done(function () {
                                    
                                })
                                .fail(function () {
                                    alert('Failed to Send Data to drag');
                                });
                        
                            let unsave = new Text("Here are unsaved changes", style6);
                            app.stage.addChild(unsave);
                            unsave.position.set(200, 800);

                            // draw horizontal time lines again
                            for (let i = 0; i < 13; i++) {
                                let line = new Graphics();
                                line.lineStyle(2, 0xFFFFFF, 1);
                                line.moveTo(120, 90 + i * 56);
                                line.lineTo(1240, 90 + i * 56);
                                line.x = 32;
                                line.y = 32;
                                app.stage.addChild(line);
                            }

                        }

                        // click
                        else {
                            this.clear();
                            let rectangle_new = new Graphics();
                            rectangle_new.beginFill(0xd8bfd8);
                            rectangle_new.drawRect(0, 0, 120, 14);
                            rectangle_new.endFill();
                            rectangle_new.x = 240 + 200 * j;
                            rectangle_new.y = 120 + 14 * i;
                            rectangle_new.interactive = false;
                            rectangle_new.buttonMode = false;
                            app.stage.addChild(rectangle_new);

                            // draw horizontal time lines
                            for (let i = 0; i < 13; i++) {
                                let line = new Graphics();
                                line.lineStyle(2, 0xFFFFFF, 1);
                                line.moveTo(120, 90 + i * 56);
                                line.lineTo(1240, 90 + i * 56);
                                line.x = 32;
                                line.y = 32;
                                app.stage.addChild(line);
                            }

                            var path = "/Availabilities/ReceiveIndex";
                            var data = { before_x: rectangle_new.x, before_y: rectangle_new.y, m: 1, userID: userID };

                            $.post(path, data)
                                .done(function () {
                                    
                                })
                                .fail(function () {
                                    alert('Failed to Send Data to click');
                                });

                           
                            let unsave = new Text("Here are unsaved changes", style6);
                            app.stage.addChild(unsave);
                            unsave.position.set(200, 800);
                        }

                    });
                }
            }
        }

    }

    /**
     * Draw the readonly slots
     * @param {any} app
     * @param {any} jsPreSlots
     */
    readonly_draw(app, jsPreSlots) {

        let Graphics = PIXI.Graphics;
        // draw slots
        for (let j = 0; j < 5; j++) {

            for (let i = 0; i < 48; i++) {

                if (jsPreSlots[i + j * 48]) // there is slot selected
                {
                    let rectangle = new Graphics();
                    rectangle.beginFill(0xd8bfd8);
                    rectangle.drawRect(0, 0, 120, 14);
                    rectangle.endFill();
                    rectangle.x = 240 + 200 * j;
                    rectangle.y = 120 + 14 * i;
                    rectangle.interactive = false;
                    rectangle.buttonMode = false;
                    app.stage.addChild(rectangle);
                }

                else {
                    let rectangle = new Graphics();
                    rectangle.beginFill(0x66CCFF);
                    rectangle.drawRect(0, 0, 120, 14);
                    rectangle.endFill();
                    rectangle.x = 240 + 200 * j;
                    rectangle.y = 120 + 14 * i;
                    rectangle.interactive = false;
                    rectangle.buttonMode = false;
                    app.stage.addChild(rectangle);
                }
            }
        }

    }
}

